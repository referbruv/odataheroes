using Microsoft.AspNetCore.Mvc;

namespace ODataHeroes.Contracts.Controllers
{
    public interface IHeroesController
    {
        IActionResult Get();
        IActionResult Get(int id);
    }
}