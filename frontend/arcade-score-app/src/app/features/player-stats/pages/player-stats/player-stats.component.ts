import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PlayerStats, ScoreService } from '../../../register-score/services/score.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-player-stats',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './player-stats.component.html',
  styleUrl: './player-stats.component.css'
})
export class PlayerStatsComponent {
  private route = inject(ActivatedRoute);
  private scoreService = inject(ScoreService);

  playerName: string = '';
  stats?: PlayerStats;

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = params.get('playerId');
      if (id) {
        const playerId = +id;;
        this.scoreService.getPlayerStats(playerId).subscribe({
          next: data => {
            this.stats = data;
          },
          error: error => {
            console.error('[PlayerStats] Erro ao buscar estatísticas do jogador', error);
          }
        });
      }
    });
  }

  formatPlayPeriod(raw: string): string {
    const [days, time] = raw.split('.');
    const [hours, minutes, seconds] = time.split(':');

    const dayPart = +days > 0 ? `${days} dia${+days > 1 ? 's' : ''}` : '';
    const hourPart = +hours > 0 ? `${hours}h` : '';
    const minutePart = +minutes > 0 ? `${minutes}min` : '';
    const secondPart = +seconds > 0 ? `${seconds}s` : '';

    return [dayPart, hourPart, minutePart, secondPart].filter(Boolean).join(' ');
  }
}