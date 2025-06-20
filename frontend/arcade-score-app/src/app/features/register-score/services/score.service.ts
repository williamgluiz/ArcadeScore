import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface RegisterScoreCommand {
  playerName: string;
  score: number;
  datePlayed: string;
}

export interface ScoreResult {
  playerId: string;
  playerName: string;
  score: number;
  datePlayed: string; // ISO string
}

export interface PlayerStats {
  playerId: number;
  playerName: string;
  totalGames: number;
  averageScore: number;
  highestScore: number;
  lowestScore: number;
  timesBrokeRecord: number;
  playPeriod: string;
}

@Injectable({
  providedIn: 'root'
})
export class ScoreService {
  private readonly apiUrl = 'https://localhost:59689/api';

  constructor(private http: HttpClient) { }

  registerScore(data: RegisterScoreCommand): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/Scores`, data);
  }

  getTop10(): Observable<ScoreResult[]> {
    return this.http.get<ScoreResult[]>(`${this.apiUrl}/Scores/ranking`);
  }

  getPlayerStats(playerId: number): Observable<PlayerStats> {
    return this.http.get<PlayerStats>(`${this.apiUrl}/Players/${playerId}/stats`);
  }
}
