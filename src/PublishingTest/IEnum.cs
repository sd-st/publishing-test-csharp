namespace PublishingTest;

public interface IEnum<TEnum, TValue>
    where TEnum : IEnum<TEnum, TValue>
{
    static abstract TEnum FromRaw(TValue value);
    TValue Raw();
}
