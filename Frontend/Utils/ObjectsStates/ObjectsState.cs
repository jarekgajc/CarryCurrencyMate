using Common.Models;
using Frontend.Models;
using Frontend.Models.RequestLoaders;
using static Common.Models.Sources.Walutomat.CurrentExchangeRate;

namespace Frontend.Utils.ObjectsStates
{
    public abstract class ObjectsState<TObject, TId> : IRequestLoaderHolder where TObject : class, IIdHolder<TId>, new()
    {
        private readonly ApiCaller<TObject, TId> _apiCaller;
        private List<TObject>? _objects;

        public bool Valid => _objects != null;
        public List<TObject> Objects => _objects ??= new List<TObject>();
        public IRequestLoader RequestLoader { get => _apiCaller; }
        public StateSubscription<TObject> StateSubscription { get; set; }

        protected abstract string BaseUrl { get; }

        protected ObjectsState()
        {
            _apiCaller = new ApiCaller<TObject, TId>
            {
                BaseUrl = BaseUrl
            };
            StateSubscription = new StateSubscription<TObject>();
        }

        public async Task<List<TObject>?> GetObjects(ApiCallerConfig<List<TObject>>? config = null)
        {
            (config ??= new ApiCallerConfig<List<TObject>>()).OnComplete += result => _objects = result;
            return await _apiCaller.GetItems(config);
        }

        public async Task<TObject?> CreateObject(TObject obj, ApiCallerConfig<TObject>? config = null)
        {
            (config ??= new ApiCallerConfig<TObject>()).OnComplete += result => _objects!.Add(result);
            return await _apiCaller.CreateItem(obj, config);
        }

        public async Task<TObject?> UpdateObject(TObject obj, ApiCallerConfig<TObject>? config = null)
        {
            (config ??= new ApiCallerConfig<TObject>()).OnComplete += result =>
            {
                int index = _objects!.FindIndex(o => o.Id.Equals(result.Id));
                _objects[index] = result;
            };
            return await _apiCaller.UpdateItem(obj, config);
        }

        public async Task<bool> DeleteObject(TId id)
        {
            return await _apiCaller.DeleteItem(id, result =>
            {
                int index = _objects!.FindIndex(o => o.Id.Equals(result));
                _objects.RemoveAt(index);
            });
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
