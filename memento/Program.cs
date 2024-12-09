using System;
using System.Collections.Generic;

// Originator: Lớp chính chứa trạng thái và lớp Memento lồng bên trong
public class TextEditor
{
    private string _content; // Trạng thái của TextEditor

    // Nested Memento class
    public class Memento
    {
        public string State { get; }

        internal Memento(string state) // Constructor chỉ có thể truy cập từ Originator
        {
            State = state;
        }
    }

    // Ghi trạng thái vào nội dung
    public void Write(string text)
    {
        _content = text;
    }

    // Lấy nội dung hiện tại
    public string GetContent()
    {
        return _content;
    }

    // Lưu trạng thái hiện tại vào Memento
    public Memento Save()
    {
        return new Memento(_content);
    }

    // Khôi phục trạng thái từ Memento
    public void Restore(Memento memento)
    {
        _content = memento.State;
    }
}

// Caretaker: Quản lý danh sách các Memento để Undo
public class History
{
    private readonly Stack<TextEditor.Memento> _history = new();

    public void Save(TextEditor.Memento memento)
    {
        _history.Push(memento);
    }

    public TextEditor.Memento Undo()
    {
        return _history.Count > 0 ? _history.Pop() : null;
    }
}

// Main: Chương trình chính minh họa
class Program
{
    static void Main()
    {
        var editor = new TextEditor();
        var history = new History();

        // Ghi nội dung và lưu trạng thái
        editor.Write("Hello, World!");
        Console.WriteLine($"Current Content: {editor.GetContent()}");
        history.Save(editor.Save());

        editor.Write("Hello, Design Patterns!");
        Console.WriteLine($"Current Content: {editor.GetContent()}");
        history.Save(editor.Save());

        editor.Write("Memento Pattern Example.");
        Console.WriteLine($"Current Content: {editor.GetContent()}");

        // Thực hiện Undo
        var memento1 = history.Undo();
        if (memento1 != null)
        {
            editor.Restore(memento1);
            Console.WriteLine($"After Undo 1: {editor.GetContent()}");
        }

        var memento2 = history.Undo();
        if (memento2 != null)
        {
            editor.Restore(memento2);
            Console.WriteLine($"After Undo 2: {editor.GetContent()}");
        }
    }
}
