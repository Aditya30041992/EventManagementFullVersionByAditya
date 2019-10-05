import { NgModule,Component} from '@angular/core';
import { RouterModule, ActivatedRoute, Router, Routes } from '@angular/router';
import {MainComponent} from '../root/products/MainComponent';
import {InterestComponent} from '../root/products/InterestComponent';
import {FlowerComponent} from '../root/products/FlowerComponent';
import {ByIdComponent} from '../root/products/ByIdComponent';

@Component({
  selector: 'tfl-products',
  template: `<!--
              <h2>Products</h2>
              <div class="navLinks">
                <a [routerLink]="['./main']">Main</a> |
                <a [routerLink]="['./interest']">Interest</a> |
                <a [routerLink]="['./flower']">Flower</a> |
                Enter id: <input #id size="6">
                <button (click)="goToProduct(id.value)">Go</button>
              </div>
              <div class="products-area">
                <router-outlet></router-outlet>
              </div>-->`
})
export class ProductsComponent {
  constructor(private router: Router,
             private route: ActivatedRoute) {
  }

  goToProduct(id:string): void {
    this.router.navigate(['./', id], {relativeTo: this.route});
  }
}
