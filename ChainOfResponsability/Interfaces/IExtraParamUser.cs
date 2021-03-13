namespace ChainOfResponsability
{
    public interface IExtraParamUser
    {
        bool ExtraParamOfRightType<T>(object extraParam);
        T ConvertExtraParam<T>(object extraParam);
    }
}
