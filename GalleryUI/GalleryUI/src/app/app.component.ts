import { CommonModule } from "@angular/common";
import { AfterViewInit, Component } from "@angular/core";
import { RouterLink, RouterLinkActive, RouterOutlet } from "@angular/router";

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [CommonModule, RouterOutlet, RouterLink, RouterLinkActive],
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
  })
  export class AppComponent implements AfterViewInit {
    title = 'routing-app';
    ngAfterViewInit(): void {

      const links = document.querySelectorAll('nav a');
      const background = document.querySelector('.link-background') as HTMLElement;
  
      const clickHandler = (el: Element, index: number) => {
        links.forEach(link => {
          link.classList.remove('active');
        });
        el.classList.add('active');
        if (background) {
          background.style.transform = `translateY(${60 * index}px)`;
        }
      };
  
      links.forEach((link, index) => {
        link.addEventListener('click', (e) => {
          e.preventDefault();
          clickHandler(e.currentTarget as HTMLElement, index);
        });
      });
  }
}