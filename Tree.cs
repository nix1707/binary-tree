using System.Collections;

[Serializable]
public class Tree<T> : IEnumerable<Tree<T>> where T : IComparable
{
    private Tree<T>? _left, _right;
    private T _data;

    public Tree(T data) => _data = data;

    public T Data => _data;

    public void Insert(T value)
    {
        if (value.CompareTo(_data) < 1)
        {
            if (_left == null)
                _left = new Tree<T>(value);
            else
                _left.Insert(value);
        }
        else
        {
            if (_right == null)
                _right = new Tree<T>(value);
            else
                _right.Insert(value);
        }
    }

    public bool Contains(T value) =>
        FindNode(value) != null;

    public IEnumerator<Tree<T>> GetEnumerator() =>
        new TreeIterator<T>(this);

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();

    public IEnumerable<Tree<T>> GetChildren()
    {
        if (_left != null)
            yield return _left;

        if (_right != null)
            yield return _right;

        yield break;
    }

    public IEnumerable<Tree<T>> GetInOrder()
    {
        var order = new List<Tree<T>>();

        void Internal(Tree<T>? tree)
        {
            if (tree == null)
                return;

            Internal(tree._left);
            order.Add(tree);
            Internal(tree._right);
        }

        Internal(this);
        return order.AsEnumerable();
    }

    public void ForEach(Action<Tree<T>> action)
    {
        foreach (var tree in this)
            action?.Invoke(tree);
    }

    public Tree<T>? FindNode(T value)
    {
        if (_data.Equals(value))
            return this;

        return value.CompareTo(_data) switch
        {
            < 1 => _left?.FindNode(value),
            1 => _right?.FindNode(value)
        };
    }

    public override string ToString() => $"{Data}";
}