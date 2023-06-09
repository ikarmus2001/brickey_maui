﻿namespace BrickeyCore.RebrickableModel
{
    public class UserProfile
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime last_activity { get; set; }
        public string last_ip { get; set; }
        public object location { get; set; }
        public Rewards rewards { get; set; }
        public Lego lego { get; set; }
        public string avatar_img { get; set; }
    }
}
