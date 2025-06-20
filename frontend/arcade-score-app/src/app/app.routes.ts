import { Routes } from '@angular/router';

import { MainLayoutComponent } from './core/layout/main-layout/main-layout.component';
import { RegisterScoreFormComponent } from './features/register-score/pages/register-score-form/register-score-form.component';
import { RankingListComponent } from './features/ranking/pages/ranking-list/ranking-list.component';
import { PlayerStatsComponent } from './features/player-stats/pages/player-stats/player-stats.component';

export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: 'register', component: RegisterScoreFormComponent },
      { path: 'ranking', component: RankingListComponent },
      { path: 'player/:playerId', component: PlayerStatsComponent },
      { path: '', redirectTo: 'register', pathMatch: 'full' },
    ],
  },
];

