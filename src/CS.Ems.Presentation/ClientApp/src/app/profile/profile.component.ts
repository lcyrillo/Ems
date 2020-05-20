import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
})
export class ProfileComponent {
  public profiles: TechnicalProfile[];
  private base = "https://localhost:44310/";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<TechnicalProfile[]>(this.base + 'api/profile/ListAll').subscribe(result => {
      this.profiles = result;
    }, error => console.error(error));
  }
}

interface TechnicalProfile {
  id: number;
  name: string;
  description: string;
}
