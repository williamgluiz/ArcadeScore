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
    this.scoreService.registerScore(this.form.value).subscribe({
      next: () => {
        alert('Score registered successfully!');
        this.form.reset();
      },
      error: (err) => {
        console.error(err);
        alert('Failed to register score.');
      },
    });

  }
  
}
