import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AnalyzeService } from '../../services/analyze.service';
import { AnalyzeResponse } from '../../models/analyze-response.model';

@Component({
  selector: 'app-url-analyzer',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './url-analyzer.html',
  styleUrls: ['./url-analyzer.css'],
})
export class UrlAnalyzer {
  url: string = '';
  result: AnalyzeResponse | null = null;
  isLoading: boolean = false;
  error: string | null = null;

  constructor(private analyzeService: AnalyzeService) {}

  analyze() {
    if (!this.url.trim()) return;

    this.isLoading = true;
    this.error = null;

    this.analyzeService.analyzeUrl(this.url).subscribe({
      next: (res) => {
        this.result = res;
        this.isLoading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Error connecting to backend';
        this.isLoading = false;
      }
    });
  }
}