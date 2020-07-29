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
  toggleUpdateForm: boolean;
  public AHero: Hero;
  constructor(private http: HttpClient) {
    http.get<Hero[]>("https://localhost:5001/api/Heros/").subscribe(
      (result) => {
        this.gridData = result;
        console.log(this.gridData);
      },
      (error) => console.error(error)
    );
  }
  ngOnInit() {
    this.AHero = null;
    this.toggleUpdateForm = false;
  }

  editHandler = (event) => {
    console.log(event.dataItem.id);
    this.toggleUpdateForm = true;
    const heroId = event.dataItem.id;
    this.http.get<Hero>(`https://localhost:5001/api/Heros/${heroId}`).subscribe(
      (item) => {
        this.AHero = item;
        return this.AHero;
      },
      (error) => console.error(error)
    );
  };
  deleteHandler = (e) => {
    console.log(e.dataItem.id);
    if (e.dataItem.id) {
      this.http
        .delete(`https://localhost:5001/api/Heros/${e.dataItem.id}`)
        .subscribe((item) => {
          this.http
            .get<Hero[]>("https://localhost:5001/api/Heros")
            .subscribe((item) => {
              this.gridData = item;
            });
        });
    } else {
      alert("no id found!");
    }
  };
  onEditHero = () => {
    this.http
      .put<Hero>(`https://localhost:5001/api/Heros/${this.AHero.id}`, {
        powertype: this.AHero.powertype,
        powerlevel: parseInt(this.AHero.powerlevel),
        gender: this.AHero.gender.toString() === "1" ? true : false,
      })
      .subscribe((item) => {
        this.toggleUpdateForm = false;
        this.http
          .get<Hero[]>("https://localhost:5001/api/Heros")
          .subscribe((item) => {
            this.gridData = item;
          });
      });
  };
}
interface Hero {
  id: string;
  powertype: string;
  gender: boolean;
  powerlevel: string;
}
