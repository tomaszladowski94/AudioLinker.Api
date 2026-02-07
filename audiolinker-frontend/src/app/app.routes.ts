import { Routes } from '@angular/router';
import { UrlAnalyzer } from './components/url-analyzer/url-analyzer';

export const routes: Routes = [
  { path: '', component: UrlAnalyzer },
  { path: 'analyze', component: UrlAnalyzer }
];