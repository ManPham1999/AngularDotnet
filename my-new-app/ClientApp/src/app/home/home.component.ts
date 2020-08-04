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
  toggleUpdateForm: boolean = false;
  public AHero: Hero;
  public opened = true;
  heroId: number;

  public close(status) {
    if (this.heroId !== null) {
      if (status === "yes") {
        this.deleteHandler(this.heroId);
        this.opened = false;
      } else {
        this.opened = false;
      }
    }
  }

  public open(e) {
    this.heroId = e.dataItem.id;
    this.toggleUpdateForm = false;
    this.opened = true;
  }
  constructor(private http: HttpClient) {
    http.get<Hero[]>("https://localhost:5001/api/Heros/").subscribe(
      (result) => {
        this.gridData = result;
      },
      (error) => console.error(error)
    );
  }
  ngOnInit() {
    this.AHero = null;
    this.opened = false;
    this.toggleUpdateForm = false;
    this.heroId = null;
  }

  editHandler = (event) => {
    this.toggleUpdateForm = !this.toggleUpdateForm;
    const heroId = event.dataItem.id;
    this.http.get<Hero>(`https://localhost:5001/api/Heros/${heroId}`).subscribe(
      (item) => {
        this.AHero = item;
        return this.AHero;
      },
      (error) => console.error(error)
    );
  };
  deleteHandler = (id: number) => {
    if (id !== null) {
      this.http
        .delete(`https://localhost:5001/api/Heros/${id}`)
        .subscribe((item) => {
          this.http
            .get<Hero[]>("https://localhost:5001/api/Heros")
            .subscribe((item) => {
              this.gridData = item;
            });
        });
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
