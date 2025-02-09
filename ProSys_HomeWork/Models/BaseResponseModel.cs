using ProSys_HomeWork.Models.Enums;

namespace ProSys_HomeWork.Models;

public class BaseResponseModel
{
    public NotificationType Type { get; set; }
    public string Message { get; set; }
}