using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace Shmelev_Backend_Task3
{
    public class ForumUser:IdentityUser
    {
        public ICollection<ModeratedBoard> ModeratedBoards { get; set; }
        public ICollection<Thread> AuthoredThreads { get; set; }
        public ICollection<Post> AuthoredPosts{ get; set; }
    }
}
