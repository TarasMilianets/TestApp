import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormArray, Validators, FormGroup } from '@angular/forms';
import { BookTypesService } from '../shared/book-types.service';
import { BooksService } from '../shared/books.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  bookForms: FormArray = this.fb.array([]);
  bookTypesList = [];

  constructor(private fb: FormBuilder,
    private booksService: BooksService,
    private bookTypesService: BookTypesService) { }

  ngOnInit() {
    this.bookTypesService.getTypesList()
      .subscribe(res => this.bookTypesList = res as []);

    this.booksService.getBooksList().subscribe(
      res => {
        if (res == [])
          this.addBookForm();
        else {
          (res as []).forEach((book: any) => {
            this.bookForms.push(this.fb.group({
              id: [book.id, Validators.min(1)],
              title: [book.title, Validators.required],
              author: [book.author, Validators.required],
              bookTypeId: [book.type.id, Validators.min(1)]
            }));
          });
        }
      }
    );
  }

  addBookForm() {
    this.bookForms.push(this.fb.group({
      id: [0],
      title: ['', Validators.required],
      author: ['', Validators.required],
      bookTypeId: [0, Validators.min(1)]
    }));
  }

  recordSubmit(fg: FormGroup) {
    this.booksService.postBook(fg.value).subscribe(
      (res: any) => {
        fg.patchValue({ bookTypeId: res.bookTypeId });
      });
  }

  onDelete(bookId, i) {
    if (bookId == 0)
      this.bookForms.removeAt(i);
    else if (confirm('Are you sure to delete this record ?'))
      this.booksService.deleteBook(bookId).subscribe(
        res => {
          this.bookForms.removeAt(i);
        });
  }
}
