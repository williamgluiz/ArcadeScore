import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ScoreService, ScoreResult } from '../../../register-score/services/score.service';

@Component({
  selector: 'app-ranking-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './ranking-list.component.html',
  styleUrls: ['./ranking-list.component.css'],
})
export class RankingListComponent implements OnInit {
  scores: ScoreResult[] = [];
  loading = true;
  error: string | null = null;

  constructor(private scoreService: ScoreService) {}

  ngOnInit(): void {
    this.scoreService.getTop10().subscribe({
      next: (data) => {
        this.scores = data;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Failed to load ranking.';
        console.error(err);
        this.loading = false;
      },
    });
  }
}

