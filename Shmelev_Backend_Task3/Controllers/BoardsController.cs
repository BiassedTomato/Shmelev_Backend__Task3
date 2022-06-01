using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Shmelev_Backend_Task3
{
    public class BoardsController : Controller
    {
        ForumContext _context;

        IBoardService _boardService;

        IUserService _userService;

        IMapper _mapper;

        public BoardsController(IMapper mapper, IUserService userService, ForumContext ctx, IBoardService srv)
        {
            _context = ctx;
            _boardService = srv;
            _userService = userService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexViewModel();


            model.Boards = _context.Boards.ToList();

            return View(model);
        }

        public async Task<IActionResult> DisplayBoard(int boardId)
        {

            var board = await _boardService.GetBoard(boardId);

            if (board == null)
            {
                return NotFound();
            }
            var t = board.Threads.First();

            BoardViewModel model = new BoardViewModel() { Threads = board.Threads.ToList(), BoardId = boardId };

            return View("BoardDisplay", model);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int boardId)
        {
            if (!HttpContext.User.IsInRole("Admin") &&
                !_userService.HasModerator(boardId, await _userService.GetUserId(HttpContext.User)))
            {
                return View("Error", new ErrorViewModel() { Message = "You cannot edit this board." });
            }

            return null;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(BoardCreateModel model)
        {
            if (!HttpContext.User.IsInRole("Admin"))
            {
                HttpContext.Response.StatusCode = 405;
                return View();
            }

            if (ModelState.IsValid)
            {

                var board = new Board();

                board = _mapper.Map<Board>(model);

                await _boardService.CreateBoard(board);


                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
