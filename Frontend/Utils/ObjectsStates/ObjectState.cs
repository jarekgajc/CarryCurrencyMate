using Common.Models;
using Frontend.Models;
using Frontend.Models.RequestLoaders;

namespace Frontend.Utils.ObjectsStates
{
    public abstract class ObjectState<TObject, TId> : IRequestLoaderHolder where TObject : class, IIdHolder<TId>, new()
    {
        private readonly ApiCaller _apiCaller;
        private TObject? _obj;
        private Action _stateHasChanged;

        public bool Valid => _obj != null;
        public TObject Value => _obj!;
        public IRequestLoader RequestLoader { get => _apiCaller; }
        public StateSubscription<TObject> Subscription { get; set; }

        protected abstract string BaseUrl { get; }

        protected ObjectState()
        {
            _apiCaller = new ApiCaller(BaseUrl);
            Subscription = new StateSubscription<TObject>();
        }

        public void AddOnSetValues(Action stateHasChanged)
        {
            _stateHasChanged = stateHasChanged;
        }

        public async Task<TObject?> GetObject(ApiCallerConfig? config = null)
        {
            TObject? result = await _apiCaller.GetItems<TObject>(config);
            if (result != null)
            {
                _obj = result;
            }
            return result;
        }

        public async Task<TObject?> GetObject(TId id, ApiCallerConfig? config = null)
        {
            TObject? result = await _apiCaller.GetItem<TObject, TId>(id, config);
            if (result != null)
            {
                _obj = result;
            }
            return result;
        }

        public async Task<TObject?> CreateOrGetObject(TObject? defaultObj = null)
        {
            TObject? response = await GetObject();
            return response ?? await CreateObject(defaultObj ?? new TObject());
        }

        public async Task<TObject?> CreateOrGetObject(TId id, TObject? defaultObj = null)
        {
            TObject? response = await GetObject(id);
            return response ?? await CreateObject(_obj = defaultObj ?? new TObject());
        }

        public async Task<TObject?> CreateObject(TObject obj, ApiCallerConfig? config = null)
        {
            TObject? result = await _apiCaller.CreateItem(obj, config);
            if (result != null)
            {
                _obj = result;
            }
            return result;
        }

        public async Task<TObject?> UpdateObject(ApiCallerConfig? config = null)
        {
            TObject? result = await _apiCaller.UpdateItem<TObject, TId>(Value, config);
            if (result != null)
            {
                _obj = result;
            }
            return result;
        }

        public async Task<bool> DeleteObject()
        {
            throw new NotImplementedException();
            //return await _apiCaller.DeleteItem(Value.Id, result =>
            //{
            //    _obj = null;
            //});
        }

        public async Task<TObject?> SaveEditorState(EditorState<TObject> editorState)
        {
            if (editorState.Exists)
            {
                _obj = editorState.Value;
                return await UpdateObject();
            }
            else
            {
                return await CreateObject(editorState.Value);
            }
        }

        public void SetValues(Action<TObject> update)
        {
            update(Value);
            Subscription.InvokeUpdate();
            _stateHasChanged.Invoke();
        }

    }
    
}
