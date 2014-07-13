using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Results
{
    public class Tweet
    {
        public string created_at { get; set; }
        public string text { get; set; }
        public User user { get; set; }
        public List<Entity> entities { get; set; }
    }

    public class User
    {
        public string profile_image_url { get; set; }
    }

    public class Url
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
    }

    public class Entity
    {
        public List<Url> urls { get; set; }
    }

    public class LandingModel
    {
        public List<Tweet> Tweets { get; set; }
    }
}