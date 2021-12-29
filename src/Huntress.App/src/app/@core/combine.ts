import { from, merge, Observable, ObservableInput } from "rxjs";
import { map, scan } from "rxjs/operators";

export function combine(...sources: ObservableInput<any>[]): Observable<any> {
  return merge(
    ...(sources.map((source, index) => from(source).pipe(map((value) => ({ value, index })))
    ) as any)).pipe(
      scan((currentValues, {value, index}) => {
        currentValues[index] = value;
        return Array.from(currentValues);
      }, new Array(sources.length))
    );
}
