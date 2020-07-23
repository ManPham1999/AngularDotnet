import { Component, Inject } from "@angular/core";
import {
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpEvent,
  HttpResponse,
  HttpClient,
} from "@angular/common/http";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
})
export class HomeComponent {
  public gridData: Hero[];
  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    http.get<Hero[]>(baseUrl + "api/Heros").subscribe(
      (result) => {
        this.gridData = result;
        console.log(this.gridData);
      },
      (error) => console.error(error)
    );
  }
}
interface Hero {
  ID: string;
  Powertype: string;
  Gender: boolean;
  Powerlevel: string;
}
