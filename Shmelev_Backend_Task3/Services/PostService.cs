using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Shmelev_Backend_Task3
{
    public class PostService:IPostService
    {
        ForumContext _context;

        IUserService _userService;

        public PostService(IUserService userService, ForumContext ctx)
        {
            _context = ctx;
            _userService = userService;
        }

        public async Task CreatePost(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task RemovePost(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task EditPost(int postId,PostEditModel model)
        {
            var post = await _context.FindAsync<Post>(postId);

            post.Text=model.Text;
            post.Modified = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task<Post> GetPost(int postId)
        {
            return await _context.Posts.Include(x=>x.Thread).Include(x=>x.Thread.Board).FirstOrDefaultAsync(x => x.Id == postId);
        }

        public async Task<bool> IsAuthor(string userId, int postId)
        {
            return (await _userService.GetPostAuthor(postId)) == userId;
        }
    }
}
