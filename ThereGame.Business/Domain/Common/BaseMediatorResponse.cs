namespace Inspirer.Business.Domain.Common;

public class BaseMediatorResponse<ResponsData, MediatorResponseStatuses>
{
    public bool IsSuccess { get; }
    public MediatorResponseStatuses Status { get; }

    public ResponsData? Data { get; }
    public BaseMediatorResponse(ResponsData data, bool isSuccess, MediatorResponseStatuses status)
    {
        IsSuccess = isSuccess;
        Status = status;
        Data = data;
    }
}

public class BaseMediatorResponse<TData>
    where TData : class?
{
    public TData? Data { get; }
    public MediatorResponseStatuses Status { get; }

    public BaseMediatorResponse(TData? data, MediatorResponseStatuses status)
    {
        Data = data;
        Status = status;
    }

    public static BaseMediatorResponse<TData?> Ok(TData? data)
    {
        return new BaseMediatorResponse<TData?>(data, MediatorResponseStatuses.OK);
    }
    public static BaseMediatorResponse<TData?> Error(MediatorResponseStatuses status)
    {
        return new BaseMediatorResponse<TData?>(null, status);
    }
}

public class ResponsData<T>
{
    public T? Data {get; private set; }
    public ResponsData(T? data) {
        Data = data;
    }
}

public enum MediatorResponseStatuses
{
    OK,
    SIGN_UP__EMAIL_EXISTS,
    SIGN_UP__INVALID_PASSWORD_FORMAT,
    SIGN_IN__INVALID_PASSWORD,
    PROFILE__NOT_FOUND,
}