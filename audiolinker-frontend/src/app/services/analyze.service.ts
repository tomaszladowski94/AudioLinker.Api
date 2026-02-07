import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_URL } from '../config/api.config';
import { AnalyzeResponse } from '../models/analyze-response.model';

@Injectable({ providedIn: 'root' })
export class AnalyzeService {
  constructor(private http: HttpClient, @Inject(API_URL) private apiUrl: string) {}

  analyzeUrl(url: string): Observable<AnalyzeResponse> {
    return this.http.post<AnalyzeResponse>(`${this.apiUrl}/analyze`, { url });
  }
}