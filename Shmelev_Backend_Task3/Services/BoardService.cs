using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shmelev_Backend_Task3
{
    public class BoardService : IBoardService
    {
        ForumContext _context;

        public async Task<List<Board>> GetAllBoards()
        {
            return await _context.Boards.ToListAsync();
        }

        public BoardService(ForumContext ctx)
        {
            _context = ctx;
        }

        public async Task CreateBoard(Board board)
        {
            await _context.Boards.AddAsync(board);


            await _context.SaveChangesAsync();
        }

        public async Task DeleteBoard(int boardId)
        {
            Board board = new Board()
            {
                Id= boardId,
            };

            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();
        }

        public async Task EditBoard(int boardId, BoardEditModel model)
        {

        }

        /// <summary>
        /// Returns the thread with a specified ID, threads included.
        /// </summary>
        /// <param name="boardId"></param>
        /// <returns></returns>
        public async Task<Board> GetBoard(int boardId)
        {
            return await _context.Boards.Include(x => x.Threads).FirstOrDefaultAsync(x => x.Id == boardId);
        }
    }
}
