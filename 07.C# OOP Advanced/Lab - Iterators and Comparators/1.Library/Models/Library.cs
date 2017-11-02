﻿using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private SortedSet<Book> books;

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books, new BookComparator());
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentInex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public void Dispose()
        {
        }

        public bool MoveNext() => ++this.currentInex < this.books.Count;

        public void Reset() => this.currentInex = -1;

        public Book Current => this.books[this.currentInex];

        object IEnumerator.Current => this.Current;
    }
}