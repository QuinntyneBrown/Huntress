import { Component, OnInit } from '@angular/core';
import { ImageContentService } from '@api/services';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent implements OnInit {

  constructor(
    private readonly _imageContentService: ImageContentService
  ) { }

  ngOnInit(): void {
  }

}
