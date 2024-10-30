using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace NotesApp.NoteModel {

    public class NoteItem {
        public NoteItem() {
            this.Id = Guid.Empty;
            this.Name = string.Empty;
            this.Contents = string.Empty;
            this.Owner = string.Empty;
            this.CreateDate = new DateTime(1900, 1, 1);
            this.Loaded = false;
       }
        
        public bool Loaded { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Contents { get; set; }
        public string Owner { get; set; }
        public DateTime CreateDate {get; set; }

    }
}