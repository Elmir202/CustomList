using System.Collections;

namespace CustomList.Collections;

public class MyList<T>:IEnumerable<T>
{
    public int Count { get; private set; }
    private int _capacity;

    public int Capacity
    {
        get => _capacity;
        set
        {
            if(value<Count)
            {
                throw new ArgumentException();
            }
            _capacity = value;
            Array.Resize(ref array,_capacity);
        }
    }
    private T[] array;
    public MyList() 
    {
        Count= 0;
        _capacity= 0;
        array= new T[_capacity];
    }
    public T this[int index]
    {
        get
        {
            if(index > Count)
            {
                throw new IndexOutOfRangeException(); 
            }
            return array[index];
        }
        set
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException();
            }
            array[index] = value;
        }
    }
    public void Add(T obj) 
    {
        if(_capacity==0)
        {
            _capacity = 4;
            Array.Resize(ref array, _capacity);
        }
        if(_capacity==Count)
        {
            _capacity *=2;
            Array.Resize(ref array, _capacity);
        }
        array[Count]=obj;
        Count++;
    }
    public bool Contains(T obj) 
    {
        for (int i = 0; i < Count; i++)
        {
            if(obj.Equals(Count))
            {
                return true;
            }
        }
        return false;
    }

    public T? Find(Predicate<T> predicate)
    {
        for (int i = 0; i < Count; i++)
        {
            if (predicate(array[i]))
            {
                return array[i];
            }
        }
        return default;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
