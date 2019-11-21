using System.ComponentModel.DataAnnotations;

namespace Enums
{
    public enum TypeMovement
    {
        [Display(Name = "Withdraw")]
        Withdraw = 1,
        [Display(Name = "Deposit")]
        Deposit = 2,
    }
}
