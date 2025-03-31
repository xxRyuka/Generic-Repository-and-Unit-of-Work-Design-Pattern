using System;
using rdp.Data.Entities;

namespace rdp.Models;

public class FeedbackViewModel
{
    // public int SenderId { get; set; 
    public int Amount { get; set; }
    public Account? SenderAccount { get; set; }
    public ApplicationUser? SenderUser { get; set; }

    public Account? RecipientAccount { get; set; }
    public ApplicationUser? RecipientUser { get; set; }
}
