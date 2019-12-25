using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Shared
{
    public static class Routes
    {
        public const string GetUserProfile = "api/user/profile";

        public const string UpdateUserProfile = "api/user/profile/update";

        public const string Auth = "api/auth";

        public const string Test = "api/test";

        public const string LogIn = "api/login";

        public const string Register = "api/register";

        public const string UploadImage = "api/user/image";

        public const string GetProfileImage = "api/user/image";

        public const string GetAllTeams = "api/teams";

        public const string GetTeam = "api/teams";

        public const string GetGroup = "api/teams/group";

        public const string GetAllMatches = "api/matches";

        public const string GetMatch = "api/matches";

        public const string GetMatchByTeam = "api/matches/team";
    }
}