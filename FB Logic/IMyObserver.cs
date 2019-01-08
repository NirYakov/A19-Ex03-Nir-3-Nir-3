namespace FB_Logic
{
    public interface IObserver<T1,T2>
    {
        void Update(T1 i_Item1 , T2 i_Item2);
    }
}