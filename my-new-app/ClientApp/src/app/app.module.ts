import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { GridModule } from "@progress/kendo-angular-grid";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ButtonsModule } from "@progress/kendo-angular-buttons";
import { CreateHeroComponent } from "./create-hero/create-hero.component";
import { DialogsModule } from '@progress/kendo-angular-dialog';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CreateHeroComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "counter", component: CounterComponent },
      { path: "fetch-data", component: FetchDataComponent },
      { path: "create-hero", component: CreateHeroComponent },
    ]),
    GridModule,
    BrowserAnimationsModule,
    ButtonsModule,
    DialogsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
