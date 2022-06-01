using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shmelev_Backend_Task3
{
    public class RolesController : Controller
    {
        IUserService _userService;
        IBoardService _boardService;

        public RolesController(IBoardService bord, IUserService srv)
        {
            _userService = srv;
            _boardService = bord;
        }


        public async Task<IActionResult> Index()
        {
            var model = new RolesEditModel()
            {
                Users = await _userService.GetAllUsers(),
                Boards = await _boardService.GetAllBoards()
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignModerator(RolesEditModel model)
        {

            if (ModelState.IsValid)
            {
                await _userService.AssignModerator(model.SelectedUserId, model.SelectedBoardId);

                return RedirectToAction("Index");

            }

            return View(model);
        }
    }
}
