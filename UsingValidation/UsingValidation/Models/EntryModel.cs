using System;

namespace UsingValidation.Models
{
    /// <summary>
    /// Simple model.
    /// </summary>
    public class EntryModel
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
    }
}
