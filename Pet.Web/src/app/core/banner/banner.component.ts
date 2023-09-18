import { Component, Input } from '@angular/core';

@Component({
  selector: 'banner',
  templateUrl: './banner.component.html',
  styleUrls: ['./banner.component.css']
})
export class BannerComponent {
  @Input() public principalTitle: string = '';
  @Input() public pageSection: string = '';
}
