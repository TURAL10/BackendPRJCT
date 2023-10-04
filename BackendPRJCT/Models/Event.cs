﻿namespace BackendPRJCT.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Image {  get; set; }
        public string Title { get; set; }
        public string Time {  get; set; }
        public string Venue { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int Day {  get; set; }
        public string Month { get; set; }
        public List<Speaker> Speakers { get; set; }

        public List<Category> Categories { get; set; }
        public Banner Banner { get; set; }
        public List<Tag> Tags { get; set; }
        public List<LatestPost> LatestPosts { get; set; }
    }
}
