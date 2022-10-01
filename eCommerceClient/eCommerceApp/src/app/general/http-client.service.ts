import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HttpClientService {
  constructor(private httpClient: HttpClient,@Inject('baseUrl') private baseUrl: string) {}

  private GenerateBaseUrl(requestParameter: Partial<RequestParameter>) :string{
    return `${requestParameter.baseUrl ? requestParameter.baseUrl : this.baseUrl}/${requestParameter.controller}${requestParameter.action ? `/${requestParameter.action}`:""}`;
  }

  get<T>(requestParameter: Partial<RequestParameter>, id?: string):Observable<T> {
    let url: string = "";
    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = `${this.GenerateBaseUrl(requestParameter)}${id ? `/${id}` : ''}${requestParameter.queryString ? `?${requestParameter.queryString}` : ""}`;

    return this.httpClient.get<T>(url, { headers: requestParameter.headers });
  }

  post<T>(requestParameter: Partial<RequestParameter>, body:T):Observable<T> {
    let url: string = "";
    if(requestParameter.fullEndPoint)
    url=requestParameter.fullEndPoint;
    else
    url=`${this.GenerateBaseUrl(requestParameter)}`

    return this.httpClient.post<T>(url,body,{headers:requestParameter.headers})
  }

  put<T>(requestParameter:Partial<RequestParameter>, body:T):Observable<T> {
    let url="";
    if(requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = this.GenerateBaseUrl(requestParameter);

    return this.httpClient.put<T>(url,body,{headers:requestParameter.headers});
  }

  delete(requestParameter:Partial<RequestParameter>, id:string){
    let url="";
    if(requestParameter.fullEndPoint)
    url = requestParameter.fullEndPoint;
    else
    url = this.GenerateBaseUrl(requestParameter);

    this.httpClient.delete(`${url}/${id}`,{headers:requestParameter.headers}).subscribe();
  }
}

export class RequestParameter {
  baseUrl?: string;
  controller?: string;
  action?: string;
  queryString?: string;
  headers?: HttpHeaders;
  fullEndPoint?: string;
}
