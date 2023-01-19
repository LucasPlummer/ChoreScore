namespace ChoreScore.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ChoresController : ControllerBase
{
    private readonly ChoresService _choresService;
    private readonly Auth0Provider _auth0provider;

    public ChoresController(ChoresService choresService, Auth0Provider auth0provider)
    {
        _choresService = choresService;
        _auth0provider = auth0provider;
    }

    [HttpGet]
    public async Task<ActionResult<List<Chore>>> Get()
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            List<Chore> chores = _choresService.Get(userInfo?.Id);
            return Ok(chores);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Chore>> GetOne(int id)
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            Chore chore = _choresService.GetOne(id, userInfo?.Id);
            return Ok(chore);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);

        }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Chore>> Create([FromBody] Chore choreData)
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            Chore chore = _choresService.Create(choreData);
            return Ok(chore);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Remove(int id)
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            string message = _choresService.Remove(id, userInfo.Id);
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}