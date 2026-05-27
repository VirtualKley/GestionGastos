using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    public int GetUsuario() =>
        int.Parse(User.FindFirst("sub")!.Value); //Obtension del id del usuario desde que se encuentra en el jwt
}