using Instagram.Dal;
using Instagram.Dal.Entity;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly MainContext MainContext;

    public CommentRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<long> AddCommentAsync(Comment comment)
    {
        await MainContext.Comments.AddAsync(comment);
        await MainContext.SaveChangesAsync();
        return comment.CommentId;
    }

   
         public async Task<List<Comment>> GetAllCommentsAsync()
    {
        var accounts = MainContext.Accounts.FirstOrDefault(a => a.AccountId == 2);

        



        //var accaunt = MainContext.Accounts.FirstOrDefault(a => a.AccountId == 1);
        //await MainContext.Entry(accaunt).Collection(b => b.Comments).LoadAsync();


        //foreach (var aC in accaunt.Comments)
        //{
        //    await LoadCommentsAsync(aC);
        //}

        var comments = await MainContext.Comments.ToListAsync();
        return comments;


    }

    //private async Task LoadCommentsAsync(Comment comment)
    //{
    //    if (comment == null) return;
    //    await MainContext.Entry(comment)
    //        .Collection(n => n.Replies).LoadAsync();

    //    if (comment.Replies == null) return;
    //    foreach (var c in comment.Replies)
    //    {
    //        await LoadCommentsAsync(c);
    //    }
    //}

    
    

    public async Task<Comment> GetCommentByIdAsync(long Id)
    {
        var comment = await MainContext.Comments
            .FirstOrDefaultAsync(b => b.CommentId == Id);
        if (comment == null)
        {
            throw new Exception("null");
        }
        return comment;
    }
}
