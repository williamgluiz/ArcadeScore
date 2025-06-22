import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ScoreService } from '../../services/score.service';

@Component({
  selector: 'app-register-score-form',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register-score-form.component.html',
  styleUrl: './register-score-form.component.css'
})
export class RegisterScoreFormComponent {
  form: FormGroup;
  showToast: boolean = false;
  toastMessage: string = '';
  toastClass: string = '';

  constructor(private fb: FormBuilder, private scoreService: ScoreService) {
    this.form = this.fb.group({
      playerName: ['', Validators.required],
      score: [null, [Validators.required, Validators.min(0)]],
      datePlayed: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.toastMessage = 'Registering score...';
    this.toastClass = 'bg-info';
    this.showToast = true;

    this.scoreService.registerScore(this.form.value).subscribe({
      next: () => {
        this.toastMessage = 'Score registered successfully!';
        this.toastClass = 'bg-success';

        this.form.reset();

        setTimeout(() => {
          this.showToast = false;
        }, 4000);
      },
      error: (err) => {
        console.error(err);
        this.toastMessage = 'Failed to register score.';
        this.toastClass = 'bg-danger';

        setTimeout(() => {
          this.showToast = false;
        }, 4000);
      }
    });
  }

}
