using Common.Models;
using Frontend.Models;
using Frontend.Models.RequestLoaders;

namespace Frontend.Utils.ObjectsStates
{
    public abstract class ObjectsState<TObject, TId> : IRequestLoaderHolder where TObject : class, IIdHolder<TId>, new()
    {
        private readonly ApiCaller _apiCaller;
        private List<TObject>? _objects;

        public bool Valid => _objects != null;
        public List<TObject> Objects => _objects ??= new List<TObject>();
        public IRequestLoader RequestLoader { get => _apiCaller; }
        public StateSubscription<TObject> StateSubscription { get; set; }

        protected abstract string BaseUrl { get; }

        protected ObjectsState()
        {
            _apiCaller = new ApiCaller
            {
                BaseUrl = BaseUrl
            };
            StateSubscription = new StateSubscription<TObject>();
        }

        public async Task<List<TObject>?> GetObjects(ApiCallerConfig? config = null)
        {
            List<TObject>? result = await _apiCaller.GetItems<List<TObject>>(config);
            if (result != null)
            {
                _objects = result;
            }
            return result;
        }

        public async Task<TObject?> CreateObject(TObject obj, ApiCallerConfig? config = null)
        {
            TObject? result = await _apiCaller.CreateItem(obj, config);
            if (result != null)
            {
                _objects!.Add(result);
            }
            return result;
        }

        public async Task<TObject?> UpdateObject(TObject obj, ApiCallerConfig? config = null)
        {
            TObject? result = await _apiCaller.UpdateItem<TObject, TId>(obj, config);
            if (result != null)
            {
                int index = _objects!.FindIndex(o => o.Id.Equals(result.Id));
                _objects[index] = result;
            }
            return result;
        }

        public async Task<bool> DeleteObject(TId id)
        {
            throw new NotImplementedException();
            //return await _apiCaller.DeleteItem(id, result =>
            //{
            //    int index = _objects!.FindIndex(o => o.Id.Equals(result));
            //    _objects.RemoveAt(index);
            //});
        }

        public async Task<TObject?> SaveEditorState(EditorState<TObject> editorState)
        {
            if (editorState.Exists)
            {
                return await UpdateObject(editorState.Value);
            }
            else
            {
                return await CreateObject(editorState.Value);
            }
        }

    }

}
