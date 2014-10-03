﻿namespace GitHubEventGetter
{
    using System;
    using System.Collections.Generic;

    // Define other methods and classes here
    public class Actor
    {
        public int id { get; set; }
        public string login { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string avatar_url { get; set; }
    }

    public class Repo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Author
    {
        public string email { get; set; }
        public string name { get; set; }
    }

    public class Commit
    {
        public string sha { get; set; }
        public Author author { get; set; }
        public string message { get; set; }
        public bool distinct { get; set; }
        public string url { get; set; }
    }

    public class Payload
    {
        public int push_id { get; set; }
        public int size { get; set; }
        public int distinct_size { get; set; }
        public string @ref { get; set; }
        public string head { get; set; }
        public string before { get; set; }
        public List<Commit> commits { get; set; }
        public string ref_type { get; set; }
        public string master_branch { get; set; }
        public string description { get; set; }
        public string pusher_type { get; set; }
    }

    public class Org
    {
        public int id { get; set; }
        public string login { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string avatar_url { get; set; }
    }

    public class GitHubEvent
    {
        public string id { get; set; }
        public string type { get; set; }
        public Actor actor { get; set; }
        public Repo repo { get; set; }
        public Payload payload { get; set; }
        public bool @public { get; set; }
        public string created_at { get; set; }
        public Org org { get; set; }
    }
}