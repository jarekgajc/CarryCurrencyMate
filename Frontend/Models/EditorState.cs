using Common.Models.Observers;

namespace Frontend.Models
{
    public delegate Task<bool> SaveEditorState<T>(EditorState<T> editorState) where T : class, new();

    public class EditorState<T> where T : class, new()
    {
        public bool Exists { get; set; }
        public T Value { get; set; }

        public EditorState(T? value)
        {
            if (value == null)
            {
                Value = new T();
            } else
            {
                Value = value;
                Exists = true;
            }
        }
    }
}
