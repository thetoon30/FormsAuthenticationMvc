using FormsAuthenticationMvc_Demo.Models;
using FormsAuthenticationMvc_Demo.ViewModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace FormsAuthenticationMvc_Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly EmployeeContext db = new EmployeeContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                string md5Pswd = GetMD5Hash(userModel.UserPassword);
                bool IsValidUser = db.Users.Any(user => user.UserName.ToLower() ==
                userModel.UserName.ToLower() && user.UserPassword == md5Pswd);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(userModel.UserName, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("","Invalid username and password");
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                var result = new CustomMembership().CreateUser(user.UserName, user.UserPassword, string.Empty, string.Empty,
                    string.Empty, true, null, out MembershipCreateStatus status);

                if (result != null)
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public static string GetMD5Hash(string value)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string GetMD5Hash2(string value, string transactionKey)
        {
            var data = Encoding.UTF8.GetBytes(value);
            // key
            var key = Encoding.UTF8.GetBytes(transactionKey);

            // Create HMAC-MD5 Algorithm;
            var hmac = new HMACMD5(key);

            // Compute hash.
            var hashBytes = hmac.ComputeHash(data);

            // Convert to HEX string.
            return System.BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}