using System.Collections;

public class TreeIterator<T> : IEnumerator<Tree<T>> where T : IComparable
{
    private readonly Tree<T> _tree;
    private readonly Queue<IEnumerator<Tree<T>>> _queue = new();

    private Tree<T>? _current;

    public TreeIterator(Tree<T> tree) => _tree = tree;

#pragma warning disable
    public Tree<T> Current => _current;
#pragma warning restore
    object IEnumerator.Current => Current;

    public void Dispose() { }

    public bool MoveNext()
    {
        if (_current == null)
        {
            Reset();
            _current = _tree;
            _queue.Enqueue(_current.GetChildren().GetEnumerator());
            return true;
        }

        while (_queue.Count > 0)
        {
            var enumerator = _queue.Peek();
            
            if(enumerator.MoveNext())
            {
                _current = enumerator.Current;
                _queue.Enqueue(_current.GetChildren().GetEnumerator());
                return true;
            }
            else
            {
                _queue.Dequeue();
            }
        }
        return false;
    }

    public void Reset() =>
        _current = null;
}
