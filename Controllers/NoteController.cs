using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NotesApp.NoteModel;

namespace NotesApp.Controllers {
    public class NotesController {
        public static object PostNote (List<NoteItem> notesStore, Guid id, string name, string contents, string owner, DateTime createDate) {
            var existingNote = notesStore.Find((note) => note.Id == id);
            if (existingNote != null) {
                existingNote.Name = name; 
                existingNote.Contents = contents;
                existingNote.Owner = owner;
                existingNote.CreateDate = createDate;
                return existingNote;
            } else 
                throw new Exception("Invalid input");
        }
        public static object PutNote (List<NoteItem> notesStore, Guid id, string name, string contents, string owner, DateTime createDate) {
            var existingNote = notesStore.Find((note) => note.Id == id);       
            if (existingNote == null && id == Guid.Empty) {
                var newNote = new NoteItem();
                newNote.Id = Guid.NewGuid();
                newNote.Name = name; 
                newNote.Contents = contents;
                newNote.Owner = owner;
                newNote.CreateDate = createDate;
                notesStore.Add(newNote);
                return newNote.Id;
            } else {
                throw new Exception("Invalid or existing record");
            }
        }
        public static NoteItem GetNote (List<NoteItem> notesStore, HttpRequest context) {
            Guid id; 
            Guid.TryParse(context?.RouteValues["id"]?.ToString(), out id);
            var existingNote = notesStore.Find((note) => note.Id == id);  
            //return notesStore.Where((note) => note.Id == id).FirstOrDefault();

            Console.WriteLine(existingNote?.Id);
            if (existingNote != null) {
                return existingNote; 
            } else {
                throw new Exception("Note with Id does not exist");
            }
        }
        public static object DeleteNote (List<NoteItem> notesStore, Guid id) {
            var existingNote = notesStore.Find((note) => note.Id == id);  
            if (existingNote != null) {
                notesStore.Remove(existingNote);  
                return true; 
            } else {
                throw new Exception("Note with Id does not exist");
            }
        }
        public static object ListNotes (List<NoteItem> notesStore) {
            return notesStore;
        }
    }
} 