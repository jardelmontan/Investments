import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SimulateCdbComponent } from './components/simulate-cdb/simulate-cdb.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, SimulateCdbComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'investment-simulator';
}
