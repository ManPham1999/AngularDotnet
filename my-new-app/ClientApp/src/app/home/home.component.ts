import { Component, Inject, OnInit } from "@angular/core";
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
export class HomeComponent implements OnInit {
  public gridData: Hero[];
  public AHero: Hero;
  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    http.get<Hero[]>(baseUrl + "api/Heros").subscribe(
      (result) => {
        this.gridData = result;
        console.log(this.gridData);
      },
      (error) => console.error(error)
    );
  }
  ngOnInit() {
    this.AHero = null;
  }

  editHandler = (event) => {
    console.log(event.dataItem.id);
    this.http
      .get<Hero>(`https://localhost:5001/api/Heros/${event.dataItem.id}`)
      .subscribe(
        (item) => {
          return (this.AHero = item);
        },
        (error) => console.error(error)
      );
    // or
    // event.dataItem
  };
}
interface Hero {
  iD: string;
  powertype: string;
  gender: boolean;
  powerlevel: string;
}
