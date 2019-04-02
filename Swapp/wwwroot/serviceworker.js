const CACHE_NAME = "swap_cache_v1";
const CONTENT = [
    //VIEWS
    "/StartPage?=%2F",
    //CSS
    "/styles/style.css"
];

self.addEventListener("install", function (event) {
    event.waitUntil(
        caches.open(CACHE_NAME).then(function (cache) {
            return cache.addAll(CONTENT);
            console.log("serviceworker installed");
        })
    );
});

self.addEventListener("fetch", function (event) {
    event.respondWith(
        fetch(event.request).catch(function () {
            return caches.match(event.request);
        })
    );
});